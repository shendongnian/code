        using System.Windows.Forms;
        using Microsoft.TeamFoundation.Client;
        using Microsoft.TeamFoundation.Server;
        namespace ConsoleApplication1
        {
            class Program
            {
                static void Main(string[] args)
                {
                    Application.EnableVisualStyles(); // Makes it look nicer from a console app.
                    //"using" pattern is recommended as the picker needs to be disposed of
                    using (TeamProjectPicker tpp = new TeamProjectPicker(TeamProjectPickerMode.MultiProject, false))
                    {
                        DialogResult result = tpp.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            System.Console.WriteLine("Selected Team Project Collection Uri: " + tpp.SelectedTeamProjectCollection.Uri);
                            System.Console.WriteLine("Selected Projects:");
                            foreach (ProjectInfo projectInfo in tpp.SelectedProjects)
                            {
                                System.Console.WriteLine(projectInfo.Name);
                            }
                        }
                    }
                }
            }
        }
