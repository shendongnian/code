    // the entity you want to validate
    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
    public class ValidationFailure
    {
        public ValidationFailure(string description) { Description = description; }
        public string Description { get; set; }
        // perhaps add other properties here if desired
    }
    public interface IValidationRule<TEntity>
    {
        ValidationFailure Test(TEntity entity);
    }
    public class ValidatesMaxAge : IValidationRule<Person>
    {
        public ValidationFailure Test(Person entity)
        {
            if (entity.Age > 100) return new ValidationFailure("Age is too high.");
        }
    }
    public class ValidatesName : IValidationRule<Person>
    {
        public ValidationFailure Test(Person entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Name))
                return new ValidationFailure("Name is required.");
        }
    }
    // to perform your validation
    var rules = new List<IValidationRule> { new ValidatesMaxAge(), new ValidatesName() };
    // test each validation rule and collect a list of failures
    var failures = rules.Select(rule => rule.Test(person))
        .Where(failure => failure != null);
    bool isValid = !failures.Any();
