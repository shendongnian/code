        class TestClassAccess
        {
            public int MyPropInt { get; set { ModifyOnAccessDenied<int>(value); } }
            public string MyPropString { get; set { ModifyOnAccessDenied<string>(value); } }
            public TestClassAccess() { }
            private static volatile bool _hasAccess = false;
            private string ModifyOnAccessDenied<string>(string propertyToChange)
            {
                if (!_hasAccess)
                    return string.Empty;
                return propertyToChange;
            }
            private int ModifyOnAccessDenied<int>(int propertyToChange)
            {
                if (!_hasAccess)
                    return -1;
                return propertyToChange;
            }
        }
