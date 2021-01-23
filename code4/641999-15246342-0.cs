        private InputType _userInputType;
        public InputType UserInputType
        {
            get
            {
                return _userInputType;
            }
            set
            {
                _userInputType = value;
                if (value == InputType.Enum2)
                    UserLetterCase = LetterCase.Enum4;
            }
        }
