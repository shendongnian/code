    public class MasterBackgroundForm : Form
    {
       public override Image BackgroundImage
       {
          get
          {
             return m_backgroundImage;
          }
          set
          {
             if (m_backgroundImage != value)
             {
                m_backgroundImage = value;
                this.OnBackgroundImageChanged(EventArgs.Empty);
             }
          }
       }
       
       protected override void OnLoad(EventArgs e)
       {
          base.OnLoad(e);
   
          // Set default background image.
          this.BackgroundImage = new Bitmap(Properties.Resources._1334821694552,
                                            new Size(800, 500));
       }
   
       private static Image m_backgroundImage;
    }
    
