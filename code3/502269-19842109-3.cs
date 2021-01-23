    >     namespace YourAPP.Views
    >     {
    >         using System;
    >         using System.Drawing;
    >         using System.Web.Mvc;
    >     
    >         public partial class Gmap : ViewUserControl
    >         {
    >             protected void Page_Load(object sender, EventArgs e)
    >             {
    >                 GMap1.enableDragging = false;
    >                 GMap1.Language = "en";
    >                 GMap1.BackColor = Color.White;
    >                 GMap1.Key = "YOUR GOOGLE KEY";
    >                 GMap1.CommercialKey="YOUR COMMERCIAL KEY";
    >             }
    >         }
    >     }
