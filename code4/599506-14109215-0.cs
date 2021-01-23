    public class TypeTree
    {
        private TypeTree()
        {
            Children = new List<TypeTree>();
        }
        public TypeTree(Type value)
            : this()
        {
            // Get to the basest class
            var typeChain = GetTypeChain(value).ToList();
            Value = typeChain.First();
            foreach (var type in typeChain.Skip(1))
            {
                Add(type);
            }
        }
        public Type Value { get; private set; }
        public TypeTree Parent { get; private set; }
        public List<TypeTree> Children { get; private set; }
        public IEnumerable<TypeTree> Interfaces
        {
            get
            {
                var myInterfaces = Children.Where(c => c.Value.IsInterface);
                return Parent == null ? myInterfaces : myInterfaces.Concat(Parent.Interfaces).Distinct();
            }
        }
        public TypeTree Find(Type type)
        {
            if (Value == type)
                return this;
            return Children.Select(child => child.Find(type)).FirstOrDefault(found => found != null);
        }
        public TypeTree Add(Type type)
        {
            TypeTree retVal = null;
            if (type.IsInterface)
            {
                if (Value.GetInterfaces().Contains(type))
                {
                    retVal = new TypeTree { Value = type, Parent = this };
                    Children.Add(retVal);
                    return retVal;
                }
            }
            var typeChain = GetTypeChain(type);
            var walkTypes =
                from baseType in typeChain
                let alreadyExists = Value == baseType || Children.Any(c => c.Value == baseType)
                where !alreadyExists
                select baseType;
            foreach (var baseType in walkTypes)
            {
                if (baseType.BaseType == Value)
                {
                    // Add this as a child of the current tree
                    retVal = new TypeTree { Value = baseType, Parent = this };
                    Children.Add(retVal);
                }
                if (Value.IsAssignableFrom(baseType))
                {
                    // we can add this as a child, potentially
                    retVal = Children.Aggregate(retVal, (current, child) => child.Add(baseType) ?? current);
                }
                // add interfaces
                var interfaces = baseType.GetInterfaces().Where(i => i != type);
                foreach (var intType in interfaces)
                {
                    (retVal ?? this).Add(intType);
                }
            }
            return retVal;
        }
        public override string ToString()
        {
            var childTypeNames = Children.Select(c => c.ToString()).Distinct();
            return string.Format("({0} {1})", Value.Name, string.Join(" ", childTypeNames));
        }
        public static Tuple<Type, IEnumerable<Type>> GetCommonBases(Type left, Type right)
        {
            var tree = new TypeTree(left);
            tree.Add(right);
            var findLeft = tree.Find(left);
            var findRight = tree.Find(right);
            var commonInterfaces =
                findLeft.Interfaces.Select(i => i.Value)
                .Intersect(findRight.Interfaces.Select(i => i.Value))
                .Distinct();
            var leftStack = new Stack<TypeTree>();
            var temp = findLeft;
            while (temp != null)
            {
                leftStack.Push(temp);
                temp = temp.Parent;
            }
            var rightStack = new Stack<TypeTree>();
            temp = findRight;
            while (temp != null)
            {
                rightStack.Push(temp);
                temp = temp.Parent;
            }
            var zippedPaths = leftStack.Zip(rightStack, Tuple.Create);
            var result = zippedPaths.TakeWhile(tup => tup.Item1.Value == tup.Item2.Value).Last();            
            return Tuple.Create(result.Item1.Value, commonInterfaces);
        }
        private static IEnumerable<Type> GetTypeChain(Type fromType)
        {
            var typeChain = new Stack<Type>();
            var temp = fromType;
            while (temp != null)
            {
                typeChain.Push(temp);
                temp = temp.BaseType;
            }
            return typeChain;
        }
    }
