                 if (manage["Name"].ToString() == "Realtek RTL8192DE Wireless LAN 802.11N PCI-E NIC MAC1")
                 {
                     Console.WriteLine(manage["Name"].ToString() + "\n");
                    
                         try
                         {  
                             //先enable再disable且要管理员权限执行
                             manage.InvokeMethod("Enable", null);
                             manage.InvokeMethod("Disable", null);
                             Console.WriteLine("设置成功");                         
                         }
                         catch
                         {
                             Console.WriteLine("设置失败");
                         }                 
                 }
            }
