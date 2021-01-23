    public enum FilterTarget { Body, AnyOtherProp };
    public Expression<Func<Message, bool>> FilterData(FilterTarget filterTarget)
    {
        string toBeFiltered = string.Empty;
        switch(filterTarget)
        {
            case FilterTarget.Body : 
            { toBeFiltered = message.Body; } break;
            case FilterTarget.AnyOtherProp : 
            { toBeFiltered = message.AnyOtherProp; } break;
            default: 
            { 
                throw new ArgumentException(
                    string.Format("Unsupported property {0}", filterTarget.ToString()
                ); 
            } 
        }
        switch (this.operatorEnum)
        {
            case FilterParameterOperatorEnum.EqualTo:
                return message => !string.IsNullOrEmpty(toBeFiltered) &&
                                  toBeFiltered.Equals(this.value, StringComparison.InvariantCultureIgnoreCase);
    
          /* CUT: other cases are similar */
        }
    }
