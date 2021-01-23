    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data;
    namespace WebApplication1
    {
        public partial class _Default : System.Web.UI.Page
        {
            //DataTable dt = new data().
            public static int Load_Counter = 0;
            List<Button> allControlsButton = new List<Button>();
            public static List<LinkButton> allControlsLinkButtonSalles = new List<LinkButton>();
            List<LinkButton> allControlsLinkButtonAffichages = new List<LinkButton>();
            List<LinkButton> allControlsLinkButtonSemaine = new List<LinkButton>();
            protected void Page_Load(object sender, EventArgs e)
            {
                literal2.Text += "<br /> counter : " + Load_Counter.ToString();
                DateTime today = DateTime.Now;
                string sToday = DateTime.Now.ToString("dd/MM/yyyy");
                string finDate = today.AddDays(+6).ToString("dd/MM/yyyy");
                literaltest.Text = "Semaine du " + sToday + " au " + finDate;
                //PlaceHolder1.Controls.Add(new LiteralControl("<br /><br /><br /> kyofu<br /><br />"));
                //foreach (string sallesel in SallesList)
                //{
                //    PlaceHolder1.Controls.Add(CreateLinkButton(sallesel + "lkbtn", sallesel, "linkButtonSalle"));
                //}
                Page_init();
            }
            protected void Page_init()
            {
                List<LinkButton> allControlsLinkButton = new List<LinkButton>();
                GetControlList<LinkButton>(Page.Controls, allControlsLinkButton);
                DateTime today = DateTime.Now;
                string sToday = DateTime.Now.ToString("dd/MM/yyyy");
                // the list of controllers is filled
                foreach (var childControl in allControlsLinkButton)
                {
                    if (childControl.CssClass == "linkButtonSalleActive" || childControl.CssClass == "linkButtonSalle")
                    {
                        allControlsLinkButtonSalles.Add(childControl);
                        literal2.Text += " allControlsLinkButtonSalles " + childControl.Text;
                    }
                    if (childControl.CssClass == "linkButtonAffichage" || childControl.CssClass == "linkButtonAffichageActive")
                    {
                        allControlsLinkButtonAffichages.Add(childControl);
                    }
                    if (childControl.CssClass == "linkButtonSemaine" || childControl.CssClass == "linkButtonSemaineActive")
                    {
                        allControlsLinkButtonSemaine.Add(childControl);
                        //SemaineSync(childControl);
                    }
                }
                literal2.Text += " taille " + allControlsLinkButtonSalles.Count();
                //literal2.Text += " Text " + allControlsLinkButtonSalles[1].Text;
                foreach (LinkButton value in allControlsLinkButtonSalles)
                {
                    literal2.Text += " <br /> Text " + value.Text;
                }
            
                /*
                 * CHANGES HERE
                 */
                literal2.Text += allControlsLinkButtonSalles.Count > 0 ?
                    " First " + allControlsLinkButtonSalles.First().Text :
                    String.Empty;
                //ListFilmsBySalle(SallesList[0]);
            }
            private void GetControlList<T>(ControlCollection controlCollection, List<T> resultCollection)
            where T : Control
            {
                foreach (Control control in controlCollection)
                {
                    //if (control.GetType() == typeof(T))
                    if (control is T) // This is cleaner
                        resultCollection.Add((T)control);
                    if (control.HasControls())
                        GetControlList(control.Controls, resultCollection);
                }
            }
        }
    }
