    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Remotion.Mixins;
    using System.ComponentModel;
    using MixinTest;
    
    [assembly: Mix(typeof(INPCTester), typeof(INotifyPropertyChangedMixin))]
    
    namespace MixinTest
    {
        //[Remotion.Mixins.CompleteInterface(typeof(INPCTester))]
        public interface ICustomINPC : INotifyPropertyChanged
        {
            void RaisePropertyChanged(string prop);
        }
    
        //[Extends(typeof(INPCTester))]
        public class INotifyPropertyChangedMixin : Mixin<object>, ICustomINPC
        {
            public event PropertyChangedEventHandler PropertyChanged;
            
            public void RaisePropertyChanged(string prop)
            {
                 PropertyChangedEventHandler handler = this.PropertyChanged;
                 if (handler != null)
                 {
                     handler(this, new PropertyChangedEventArgs(prop));
                 }
            }
        }
    
        public class ImplementsINPCAttribute : UsesAttribute 
        {
            public ImplementsINPCAttribute()
                : base(typeof(INotifyPropertyChangedMixin))
            {
    
            }
        }
    
        //[ImplementsINPC]
        public class INPCTester
        {
            private string m_Name;
            public string Name
            {
                get { return m_Name; }
                set
                {
                    if (m_Name != value)
                    {
                        m_Name = value;
                        ((ICustomINPC)this).RaisePropertyChanged("Name");
                    }
                }
            }
        }
    
        public class INPCTestWithoutMixin : ICustomINPC
        {
            private string m_Name;
            public string Name
            {
                get { return m_Name; }
                set
                {
                    if (m_Name != value)
                    {
                        m_Name = value;
                        this.RaisePropertyChanged("Name");
                    }
                }
            }
    
            public void RaisePropertyChanged(string prop)
            {
                PropertyChangedEventHandler handler = this.PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(prop));
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
    }
