    public enum BaudRate
    {
        BR115200 = 7,
        BR19200 = 4,
        BR230400 = 8,
        BR2400 = 1,
        BR38400 = 5,
        BR4800 = 2,
        BR57600 = 6,
        BR9600 = 3
      }
    }
    
    foreach (string name in Enum.GetNames(BaudRate))
    {
    	cmbEnum.Items.Add(name.Replace("BR",""));
    }
