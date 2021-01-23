    protected virtual void CloseDialog(object sender, EventArgs e)
    {
         if (_mFather!= null)
         {
    
             _mFather.Show();
    
             _mFather.TopLevelControl.Controls.Remove(this);
    
             _mFather.SubExe.UpdateParent();
    
          }
    
    
    }
