                if (txtSupervisor.Text == "sa")
                {
                    SettingManger.Instance.IsAdmin = Enumerator.AdminType.SUPERADMIN;    
                }
                else // no need for else if statement
                {
                    dateTimePicker1.Value = DateTime.Now;
                }
