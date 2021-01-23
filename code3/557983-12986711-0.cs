    foreach (string s in splitarray)
    {
      if(Richtextbox1.Text.Trim() == string.Empty)//Checking for first Array Item
      {
       Richtextbox1.Text =  s;
      }
      else
      {
       Richtextbox1.Text = Richtextbox1.Text + s;
      }
    }
