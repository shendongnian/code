    [Serializable]
    [IntroduceInterface(typeof(INotifyPropertyChanged), OverrideAction = InterfaceOverrideAction.Ignore)]
    [MulticastAttributeUsage(MulticastTargets.Class, Inheritance = MulticastInheritance.Strict )]
    public class NotifyAttribute : InstanceLevelAspect, INotifyPropertyChanged
    {        
        [ImportMember("OnPropertyChanged", IsRequired = false)] 
        public Action<string> OnPropertyChangedMethod;    
     
        [IntroduceMember(Visibility = Visibility.Family, IsVirtual = true, OverrideAction = MemberOverrideAction.Ignore)]
        public void OnPropertyChanged( string propertyName )
        {
            if (PropertyChanged != null )            
                PropertyChanged(Instance, new PropertyChangedEventArgs(propertyName));            
        }
    
        [IntroduceMember(OverrideAction = MemberOverrideAction.Ignore)]
        public event PropertyChangedEventHandler PropertyChanged;
    
        [OnLocationSetValueAdvice]
        [MulticastPointcut(Targets = MulticastTargets.Property,  Attributes = MulticastAttributes.Instance)]
        public void OnPropertySet( LocationInterceptionArgs args )
        {            
            if (args.Value == args.GetCurrentValue()) return;
         
            args.ProceedSetValue();
            this.OnPropertyChangedMethod.Invoke( args.Location.Name );            
        }
    }
