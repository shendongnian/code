    public void eng_OnGetSpeedDone(OBDIIEngineEventArgs args)
            {
                if (this.InvokeRequired)
                {
                    Action action = () => eng_OnGetSpeedDone(args);
                    Invoke(action);
                    return;
                }
                if (!args.OBDResultNoData)
                    brzina_ele.Text = arg.OBDValue.ToString();
                else
                    brzina_ele.Text = "0";
    
            }
