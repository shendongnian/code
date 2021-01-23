        [NotMapped]
        public string FirstName
        {
            get
            {
                return Participant.FirstNameExpression.Compile().Invoke(this);
                // if you do this, you might want to consider caching the delegate
                // returned by Expression.Compile()
            }
        }
    }
