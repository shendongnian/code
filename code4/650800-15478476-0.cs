    if (ManageMent.Login_Check!=false)
        {
                new System.Threading.Thread(new System.Threading.ThreadStart(()=>{
                    Application.Run(new Control_Center());
                })).Start();
    
                this.Dispose();
    }
