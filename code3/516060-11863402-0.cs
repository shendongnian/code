    protected void SubmitButton_Click(object sender, EventArgs e)
    {  
       List<string> projectsInCSharp = new List<string>();
       int count = Convert.ToInt32(Request["textBoxCount"]);
       for(int i = 1; i <= count; i++)
       {
          if(Request["Projects[" +  i + "]"] != null)
          { 
            projectsInCSharp.Add(Request["Projects[" +  i + "]"]);
          }
      }
    }
