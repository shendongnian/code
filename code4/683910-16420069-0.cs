     public ControlType ControlTypeEnum
     {
         get { return (ControlType)Enum.Parse(typeof(ControlType), dbCtrlType); }
         set { dbCtrlType = dbCtrlType.ToString(); }
     }
