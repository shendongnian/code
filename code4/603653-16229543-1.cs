    public void puerto_serie_DataReceived(object sender,
                                       System.IO.Ports.SerialDataReceivedEventArgs e)
    {
      string a = this.puerto_serie.ReadLine().Trim();
      leer(a);
    }
    delegate void SetTextCallback(string text);
    void leer(String b)
    {
      if (valores.InvokeRequired)
      {
        SetTextCallback d = new SetTextCallback(leer);
        this.Invoke(d, new object[] { b });
      }
      else
      {
        valores.Text += this.puerto_serie.ReadLine().Trim()+"\n";
      }
    }
