    //use the convention of eventName+EventArgs
    public class MemberChangedEventArgs : EventArgs {
        public readonly ExtendedVector2 OldValue {
            get;
            set;
        }
        
        public readonly ExtendedVector2 LastValue {
            get;
            set;
        }
        //To give the chance to know which value changed
        public readonly Member MemberChanged{
            get;
            set;
        }
    
        public MemberChangedEventArgs(ExtendedVector2 OldValue, ExtendedVector2 NewValue){
            this.OldValue = OldValue;
            this.NewValue = NewValue;
            if(OldValue.Y != NewValue.Y)
                MemberChanged = Member.Y;
            else if(OldValue.X != OldValue.X)
                MemberChanged = Member.X;
        } 
    }
    
    public enum Member {
        X,
        Y
    }
