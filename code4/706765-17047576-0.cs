    public enum CodeValue { Wakeup, ShutDown, CheckUpdate, ForceUpdate, Online, Offline, Login, Logoff, Zip };
    public enum TypeValue { Control, Notification, Data, Invalid }
    public class Code
    {
        public CodeValue CodeValue
        {
            get;
            private set;
        }
        public TypeValue TypeValue
        {
            get;
            private set;
        }
        public Code( CodeValue code )
        {
            CodeValue = code;
            DetermineType();
            if ( TypeValue == TypeValue.Invalid )
                throw new ArgumentException( "code" );
        }
        private bool IsControl()
        {
            return CodeValue == CodeValue.Wakeup || CodeValue == CodeValue.ShutDown || CodeValue == CodeValue.CheckUpdate || CodeValue == CodeValue.ForceUpdate;
        }
        private bool IsNotification()
        {
            return CodeValue == CodeValue.Online || CodeValue == CodeValue.Offline || CodeValue == CodeValue.Login || CodeValue == CodeValue.Logoff;
        }
        private bool IsData()
        {
            return CodeValue == CodeValue.Zip;
        }
        private void DetermineType()
        {
            if ( IsControl() )
                TypeValue = TypeValue.Control;
            if ( IsNotification() )
                TypeValue = TypeValue.Notification;
            if ( IsData() )
                TypeValue = TypeValue.Data;
            TypeValue = TypeValue.Invalid;
        }
    }
