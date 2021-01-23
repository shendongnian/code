    public void UpdateProgressBar(int i)
    {
       if(myProgressBar.Value < myProgressBar.Maximum)
       {
          if(myProgressBar + i > myProgressBar.Maximum)
              myProgressBar.Value = myProgressBar.Maximum;
          else myProgressBar.Value += i;
       }
       myProgressBar.Update();
    }
