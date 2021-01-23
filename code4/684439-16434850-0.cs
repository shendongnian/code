    public void ShowValue(int num)
      {
    
           if(label7.InvokeREquired)
           {
               Action a = () => ShowValue(num);
               label7.Invoke(a);
           }
           else
            this.label7.Text = num.ToString();    
    
      }
