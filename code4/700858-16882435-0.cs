    var res = cmmd.ExecuteScalar();
    
    int pain;
    if (int.TryParse(res , out pain))
    {
      if(pain==1){
          MessageBox.Show("NO");
       }else{
          MessageBox.Show("YES");  
       }               
    }
    read.Dispose();
    cmmd.Dispose();
