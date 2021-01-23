    public class Page1
    { 
       private void OpenPage2()
       {
          Page2 p = new Page2( this );
          p.Show();
       }
       public void LoadLv() ...
    }
    public class Page2
    {
       private Page1 page1;
       public Page2( Page1 page1 )
       {
          this.page1 = page1;
       }
       public void CloseButton()
       {
          this.page1.LoadLV();
       }
    }
