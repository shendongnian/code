                string pname = textBoxPumpName.Text;
                m_OwnerPump.Dispatcher.Invoke(
                  System.Windows.Threading.DispatcherPriority.Normal,
                  new Action(
                  delegate()
                  {
                      m_OwnerPump.Name = pname;
                      m_OwnerPump.Numbers = numbers.ToArray<string>();
                      m_OwnerPump.EnergyConsumed = power;
                  }));
