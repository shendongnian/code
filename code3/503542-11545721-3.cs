    public void CheckKeyState()
    {
       if ((GetKeyState(0x14) & 0x0001)!=0)
          System.Windows.Forms.MessageBox.Show("Caps Lock ON!");
       else
          System.Windows.Forms.MessageBox.Show("Caps Lock OFF!");
    }
