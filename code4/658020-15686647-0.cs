    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    namespace Test
    {
        public class RpmPowerModel : INotifyPropertyChanged
        {
            #region Properties
    
            public int Rpm
            {
                get { return _rpm; }
                set
                {
                    if (_rpm != value)
                    {
                        _rpm = value;
                        RaisePropertyChanged("Rpm");
                    }
                }
            }
    
            private int _rpm;
    
            public int Power
            {
                get { return _power; }
                set
                {
                    if (_power != value)
                    {
                        _power = value;
                        RaisePropertyChanged("Power");
                    }
                }
            }
    
            private int _power;
    
            #endregion
    
            #region Implementation of INotifyPropertyChanged
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected void RaisePropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
    
            #endregion
    
            public static List<RpmPowerModel> LoadItems(List<int> rpms, List<int> powers)
            {
                if (rpms == null)
                {
                    throw new ArgumentNullException("rpms");
                }
    
                if (powers == null)
                {
                    throw new ArgumentNullException("powers");
                }
    
                var result = new List<RpmPowerModel>(Math.Max(rpms.Count, powers.Count));
    
                for (int i = 0; i < Math.Max(rpms.Count, powers.Count); i++)
                {
                    var model = new RpmPowerModel
                    {
                        Rpm = i < rpms.Count ? rpms[i] : 0,
                        Power = i < powers.Count ? powers[i] : 0
                    };
    
                    result.Add(model);
                }
    
                return result;
            }
        }
    }
