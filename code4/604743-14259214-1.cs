    public class MyClass
    {
        private readonly bool _isCurrentUserAMember;
        public MyClass(bool isCurrentUserAMember)
        {
            _isCurrentUserAMember = isCurrentUserAMember;
        }
    
        public void SomeMethod()
        {
            if (_isCurrentUserAMember)
            {
                // do some business logic for members
            }
            else
            {
                // do some other business logic for non-members
            }
        }
    }
