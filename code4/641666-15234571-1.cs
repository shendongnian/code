        public enum Test
        {
            UnitedStates,
            NewZealand
        }
        Test MyEnum = EnumFromString<Test>("New Zealand"); // Returns 'NewZealand'
