    public interface IValidationConfigurationMemberCreator<TEntity>
    {
        ValidationConfigurationBuilderRuleset<TEntity> BuilderRuleset { get; }
    }
    public static class ValidationConfigurationBuilderExtensions
    {
        public static ValidationConfigurationBuilderProperty<TEntity, TField> ForField<TEntity, TField>(
            this IValidationConfigurationMemberCreator<TEntity> memberCreator,
            Expression<Func<TEntity, TField>> fieldSelector)
        {
            string fieldName = ExtractFieldName(fieldSelector);
            return new ValidationConfigurationBuilderProperty<TEntity, TField>(memberCreator.BuilderRuleset,
                fieldName);
        }
        public static ValidationConfigurationBuilderProperty<TEntity, TProperty>
            ForProperty<TEntity, TProperty>(
            this IValidationConfigurationMemberCreator<TEntity> memberCreator,
            Expression<Func<TEntity, TProperty>> propertySelector)
        {
            string propertyName = ExtractPropertyName(propertySelector);
            return new ValidationConfigurationBuilderProperty<TEntity, TProperty>(memberCreator.BuilderRuleset,
                propertyName);
        }
        private static string ExtractPropertyName(LambdaExpression propertySelector)
        {
            if (propertySelector == null)
            {
                throw new ArgumentNullException("propertySelector");
            }
            var body = propertySelector.Body as MemberExpression;
            if (body == null || body.Member.MemberType != MemberTypes.Property)
            {
                throw new ArgumentException("The given expression should return a property.",
                    "propertySelector");
            }
            return body.Member.Name;
        }
        private static string ExtractFieldName(LambdaExpression fieldSelector)
        {
            if (fieldSelector == null)
            {
                throw new ArgumentNullException("fieldSelector");
            }
            var body = fieldSelector.Body as MemberExpression;
            if (body == null || body.Member.MemberType != MemberTypes.Field)
            {
                throw new ArgumentException("The given expression should return a field.",
                    "fieldSelector");
            }
            return body.Member.Name;
        }
        public static ValidationConfigurationBuilderMember<TEntity, TMember> AddRangeValidator<TEntity, TMember>(
           this ValidationConfigurationBuilderMember<TEntity, TMember> memberBuilder,
          RangeData<TMember> rangeData) where TMember : IComparable
        {
            memberBuilder.AddValidator(rangeData.CreateValidator());
            return memberBuilder;
        }
    }
    public class ValidationConfigurationBuilder : IConfigurationSource
    {
        private readonly ValidationSettings settings;
        private readonly HashSet<string> alternativeRulesetNames = new HashSet<string>(StringComparer.Ordinal);
        private string defaultRulesetName;
        public ValidationConfigurationBuilder()
        {
            this.settings = new ValidationSettings();
        }
        public event EventHandler<ConfigurationSourceChangedEventArgs> SourceChanged;
        public void RegisterDefaultRulesetForAllTypes(string rulesetName)
        {
            if (string.IsNullOrEmpty(rulesetName))
            {
                throw new ArgumentNullException("rulesetName");
            }
            if (this.settings.Types.Count > 0)
            {
                throw new InvalidOperationException("Registeringen rulesets for all types is not possible " +
                 "after types are registered.");
            }
            this.defaultRulesetName = rulesetName;
        }
        public void RegisterAlternativeRulesetForAllTypes(string rulesetName)
        {
            if (string.IsNullOrEmpty(rulesetName))
            {
                throw new ArgumentNullException("rulesetName");
            }
            if (this.settings.Types.Count > 0)
            {
                throw new InvalidOperationException("Registeringen rulesets for all types is not possible " +
                 "after types are registered.");
            }
            if (this.alternativeRulesetNames.Contains(rulesetName))
            {
                throw new InvalidOperationException("There already is a ruleset with this name: " +
                    rulesetName);
            }
            this.alternativeRulesetNames.Add(rulesetName);
        }
        public ValidationConfigurationBuilderType<T> ForType<T>()
        {
            ValidatedTypeReference typeReference;
            if (this.settings.Types.Contains(typeof(T).FullName))
            {
                typeReference = this.settings.Types.Get(typeof(T).FullName);
            }
            else
            {
                typeReference = new ValidatedTypeReference(typeof(T))
                {
                    AssemblyName = typeof(T).Assembly.GetName().FullName,
                };
                if (this.defaultRulesetName != null)
                {
                    typeReference.Rulesets.Add(new ValidationRulesetData(this.defaultRulesetName));
                    typeReference.DefaultRuleset = this.defaultRulesetName;
                }
                foreach (var alternativeRulesetName in this.alternativeRulesetNames)
                {
                    typeReference.Rulesets.Add(new ValidationRulesetData(alternativeRulesetName));
                }
                this.settings.Types.Add(typeReference);
            }
            return new ValidationConfigurationBuilderType<T>(this, typeReference);
        }
        ConfigurationSection IConfigurationSource.GetSection(string sectionName)
        {
            if (sectionName == ValidationSettings.SectionName)
            {
                return this.settings;
            }
            return null;
        }
        #region IConfigurationSource Members
        void IConfigurationSource.Add(string sectionName, ConfigurationSection configurationSection)
        {
            throw new NotImplementedException();
        }
        void IConfigurationSource.AddSectionChangeHandler(string sectionName, ConfigurationChangedEventHandler handler)
        {
            throw new NotImplementedException();
        }
        void IConfigurationSource.Remove(string sectionName)
        {
            throw new NotImplementedException();
        }
        void IConfigurationSource.RemoveSectionChangeHandler(string sectionName, ConfigurationChangedEventHandler handler)
        {
            throw new NotImplementedException();
        }
        void IDisposable.Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
        protected virtual void Dispose(bool disposing)
        {
        }
    }
    public class ValidationConfigurationBuilderType<TEntity>
        : IValidationConfigurationMemberCreator<TEntity>
    {
        internal ValidationConfigurationBuilderType(ValidationConfigurationBuilder builder,
            ValidatedTypeReference typeReference)
        {
            this.Builder = builder;
            this.TypeReference = typeReference;
        }
        ValidationConfigurationBuilderRuleset<TEntity> IValidationConfigurationMemberCreator<TEntity>.BuilderRuleset
        {
            get { return this.ForDefaultRuleset(); }
        }
        internal ValidationConfigurationBuilder Builder { get; private set; }
        internal ValidatedTypeReference TypeReference { get; private set; }
        
        public ValidationConfigurationBuilderRuleset<TEntity> ForDefaultRuleset()
        {
            if (string.IsNullOrEmpty(this.TypeReference.DefaultRuleset))
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                    "There hasn't been an default ruleset registered for the type {0}.", typeof(TEntity).FullName));
            }
            var defaultRuleset = this.TypeReference.Rulesets.Get(this.TypeReference.DefaultRuleset);
            if (defaultRuleset == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                    "The default ruleset with name {0} is missing from type {1}.",
                    this.TypeReference.DefaultRuleset, typeof(TEntity).FullName));
            }
            return new ValidationConfigurationBuilderRuleset<TEntity>(this, defaultRuleset);
        }
        public ValidationConfigurationBuilderRuleset<TEntity> ForRuleset(string rulesetName)
        {
            var ruleset = this.TypeReference.Rulesets.Get(rulesetName);
            if (ruleset == null)
            {
                ruleset = new ValidationRulesetData(rulesetName);
                this.TypeReference.Rulesets.Add(ruleset);
                //throw new InvalidOperationException(String.Format(CultureInfo.InvariantCulture,
                //    "The ruleset with name '{0}' has not been registered yet for type {1}.",
                //    rulesetName, this.TypeReference.Name));
            }
            return new ValidationConfigurationBuilderRuleset<TEntity>(this, ruleset);
        }
        internal void CreateDefaultRuleset(string rulesetName)
        {
            if (this.TypeReference.Rulesets.Get(rulesetName) != null)
            {
                throw new InvalidOperationException(String.Format(CultureInfo.InvariantCulture,
                    "The ruleset with name '{0}' has already been registered yet for type {1}.",
                    rulesetName, this.TypeReference.Name));
            }
            if (!string.IsNullOrEmpty(this.TypeReference.DefaultRuleset))
            {
                throw new InvalidOperationException(String.Format(CultureInfo.InvariantCulture,
                    "The type {0} already has a default ruleset.", this.TypeReference.Name));
            }
            var ruleset = new ValidationRulesetData(rulesetName);
            this.TypeReference.Rulesets.Add(ruleset);
            this.TypeReference.DefaultRuleset = rulesetName;
        }
        internal void CreateAlternativeRuleset(string rulesetName)
        {
            if (this.TypeReference.Rulesets.Get(rulesetName) != null)
            {
                throw new InvalidOperationException(String.Format(CultureInfo.InvariantCulture,
                    "The ruleset with name '{0}' has already been registered yet for type {1}.",
                    rulesetName, this.TypeReference.Name));
            }
            var ruleset = new ValidationRulesetData(rulesetName);
            this.TypeReference.Rulesets.Add(ruleset);
        }
    }
    public class ValidationConfigurationBuilderRuleset<TEntity> : IValidationConfigurationMemberCreator<TEntity>
    {
        internal ValidationConfigurationBuilderRuleset(
            ValidationConfigurationBuilderType<TEntity> builderType,
            ValidationRulesetData ruleset)
        {
            this.BuilderType = builderType;
            this.Ruleset = ruleset;
        }
        internal ValidationConfigurationBuilderType<TEntity> BuilderType { get; private set; }
        ValidationConfigurationBuilderRuleset<TEntity>
            IValidationConfigurationMemberCreator<TEntity>.BuilderRuleset { get { return this; } }
        internal ValidationRulesetData Ruleset { get; private set; }
        internal ValidationConfigurationBuilderRuleset<TEntity> AddValidator(ValidatorData validator)
        {
            if (validator == null)
            {
                throw new ArgumentNullException("validator");
            }
            // 'Name' is the default value when the validator has not been given a name.
            if (validator.Name == "Name")
            {
                // In that case we set the name to something more specific.
                validator.Name = typeof(TEntity).Name + "_" + validator.Type.Name;
            }
            var validators = this.Ruleset.Validators;
            // When that specific name already exist, we add a number to that name to ensure uniqueness.
            if (validators.Contains(validator.Name))
            {
                validator.Name += "_" + validators.Count.ToString();
            }
            validators.Add(validator);
            return this;
        }
    }
    public abstract class ValidationConfigurationBuilderMember<TEntity, TMember>
        : IValidationConfigurationMemberCreator<TEntity>
    {
        private readonly ValidationConfigurationBuilderRuleset<TEntity> builderRuleset;
        internal ValidationConfigurationBuilderMember(
            ValidationConfigurationBuilderRuleset<TEntity> builderRuleset, string memberName)
        {
            this.builderRuleset = builderRuleset;
            this.MemberName = memberName;
        }
        ValidationConfigurationBuilderRuleset<TEntity>
            IValidationConfigurationMemberCreator<TEntity>.BuilderRuleset { get { return this.builderRuleset; } }
        internal ValidationConfigurationBuilderRuleset<TEntity> BuilderRuleset
        {
            get { return this.builderRuleset; }
        }
        internal string MemberName { get; private set; }
        public ValidationConfigurationBuilderMember<TEntity, TMember> AddValidator(Validator validator)
        {
            if (validator == null)
            {
                throw new ArgumentNullException("validator");
            }
            return AddValidator(new SingletonValidatorData<TEntity>(validator));
        }
        public ValidationConfigurationBuilderMember<TEntity, TMember> AddValidator(ValidatorData validatorData)
        {
            if (validatorData == null)
            {
                throw new ArgumentNullException("validatorData");
            }
            var memberReference = this.GetOrCreateMemberReference();
            // 'Name' is the default value when the validator has not been given a name.
            if (validatorData.Name == "Name")
            {
                // In that case we set the name to something more specific.
                validatorData.Name = typeof(TEntity).Name + "_" +
                    this.BuilderRuleset.Ruleset.Name + "_" + validatorData.Type.Name;
            }
            // When that specific name already exist, we add a number to that name to ensure uniqueness.
            if (memberReference.Validators.Contains(validatorData.Name))
            {
                validatorData.Name += "_" + memberReference.Validators.Count.ToString();
            }
            memberReference.Validators.Add(validatorData);
            return this;
        }
        internal abstract ValidatedMemberReference GetOrCreateMemberReference();
    }
    public class ValidationConfigurationBuilderProperty<TEntity, TProperty>
        : ValidationConfigurationBuilderMember<TEntity, TProperty>
    {
        internal ValidationConfigurationBuilderProperty(
            ValidationConfigurationBuilderRuleset<TEntity> builderRuleset, string propertyName)
            : base(builderRuleset, propertyName)
        {
        }
        internal override ValidatedMemberReference GetOrCreateMemberReference()
        {
            var properties = this.BuilderRuleset.Ruleset.Properties;
            var propertyReference = properties.Get(this.MemberName);
            if (propertyReference == null)
            {
                propertyReference = new ValidatedPropertyReference(this.MemberName);
                properties.Add(propertyReference);
            }
            return propertyReference;
        }
    }
    public class ValidationConfigurationBuilderField<TEntity, TField>
        : ValidationConfigurationBuilderMember<TEntity, TField>
    {
        internal ValidationConfigurationBuilderField(
            ValidationConfigurationBuilderRuleset<TEntity> builderRuleset, string fieldName)
            : base(builderRuleset, fieldName)
        {
        }
        internal override ValidatedMemberReference GetOrCreateMemberReference()
        {
            var fields = this.BuilderRuleset.Ruleset.Fields;
            var fieldReference = fields.Get(this.MemberName);
            if (fieldReference == null)
            {
                fieldReference = new ValidatedFieldReference(this.MemberName);
                fields.Add(fieldReference);
            }
            return fieldReference;
        }
    }
    internal class SingletonValidatorData<TEntity> : ValidatorData
    {
        private readonly Validator validator;
        public SingletonValidatorData(Validator validator)
            : base(typeof(TEntity).Name + "ValidatorData", typeof(TEntity))
        {
            this.validator = validator;
        }
        protected override Validator DoCreateValidator(Type targetType)
        {
            return this.validator;
        }
    }
    [DebuggerDisplay("Range (LowerBound: {LowerBound}, LowerBoundType: {LowerBoundType}, UpperBound: {UpperBound}, UpperBoundType: {UpperBoundType})")]
    public class RangeData<T> where T : IComparable
    {
        private T lowerBound;
        private RangeBoundaryType lowerBoundType;
        private bool lowerBoundTypeSet;
        private T upperBound;
        private RangeBoundaryType upperBoundType;
        private bool upperBoundTypeSet;
        public T LowerBound
        {
            get
            {
                return this.lowerBound;
            }
            set
            {
                this.lowerBound = value;
                if (!this.lowerBoundTypeSet)
                {
                    this.lowerBoundType = RangeBoundaryType.Inclusive;
                }
            }
        }
        public RangeBoundaryType LowerBoundType
        {
            get
            {
                return this.lowerBoundType;
            }
            set
            {
                this.lowerBoundType = value;
                this.lowerBoundTypeSet = true;
            }
        }
        public T UpperBound
        {
            get
            {
                return this.upperBound;
            }
            set
            {
                this.upperBound = value;
                if (!this.upperBoundTypeSet)
                {
                    this.upperBoundType = RangeBoundaryType.Inclusive;
                }
            }
        }
        public RangeBoundaryType UpperBoundType
        {
            get
            {
                return this.upperBoundType;
            }
            set
            {
                this.upperBoundType = value;
                this.upperBoundTypeSet = true;
            }
        }
        public bool Negated { get; set; }
        public virtual string MessageTemplate { get; set; }
        public virtual string MessageTemplateResourceName { get; set; }
        public virtual string MessageTemplateResourceTypeName { get; set; }
        public virtual string Tag { get; set; }
        internal RangeValidator CreateValidator()
        {
            return new RangeValidator(this.LowerBound, this.LowerBoundType, this.UpperBound,
                this.UpperBoundType, this.GetMessageTemplate(), this.Negated)
            {
                Tag = this.Tag,
            };
        }
        internal string GetMessageTemplate()
        {
            if (!string.IsNullOrEmpty(this.MessageTemplate))
            {
                return this.MessageTemplate;
            }
            Type messageTemplateResourceType = this.GetMessageTemplateResourceType();
            if (messageTemplateResourceType != null)
            {
                return ResourceStringLoader.LoadString(messageTemplateResourceType.FullName,
                    this.MessageTemplateResourceName, messageTemplateResourceType.Assembly);
            }
            return null;
        }
        private Type GetMessageTemplateResourceType()
        {
            if (!string.IsNullOrEmpty(this.MessageTemplateResourceTypeName))
            {
                return Type.GetType(this.MessageTemplateResourceTypeName);
            }
            return null;
        }
    }
