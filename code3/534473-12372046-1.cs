    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.VersionControl.Client;
    using System.IO;
    using Microsoft.TeamFoundation.VersionControl.Common;
    namespace AddToSourceControl
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    Uri collectionUri = new Uri(args[0]);
                    string serverPath = args[1];
                    string localPath = args[2];
                    using (TfsTeamProjectCollection tfs = new TfsTeamProjectCollection(collectionUri))
                    {
                        VersionControlServer vcs = tfs.GetService<VersionControlServer>();
                        for (int i = 0; i < 5; i++)
                        {
                            string uniqueId = Guid.NewGuid().ToString();
                            if (i > 0)
                            {
                                Console.WriteLine();
                            }
                            Console.WriteLine("Creating a workspace and checking in with id " + uniqueId);
                            CheckinLocalFolder(vcs, serverPath, localPath, uniqueId);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Failure: " + e);
                }
            }
            private static void CheckinLocalFolder(VersionControlServer vcs, string serverPath, string localPath, string uniqueId)
            {
                string uniqueServerPath = VersionControlPath.Combine(serverPath, uniqueId);
                string uniqueFolder = Path.Combine(localPath, uniqueId);
                string uniqueFile = Path.Combine(uniqueFolder, uniqueId + ".txt");
                // Create a local folder with a file in it
                Directory.CreateDirectory(uniqueFolder);
                using (TextWriter output = new StreamWriter(uniqueFile))
                {
                    output.WriteLine("This is " + uniqueId);
                    output.Close();
                }
                Console.WriteLine("Created file " + uniqueFile);
                Workspace workspace = vcs.CreateWorkspace(uniqueId, vcs.AuthorizedUser, "", new WorkingFolder[] {
                    new WorkingFolder(uniqueServerPath, uniqueFolder)
                });
                Console.WriteLine("Created TFS workspace " + uniqueId);
                workspace.PendAdd(uniqueFolder, true);
                PendingChange[] pendingChanges = workspace.GetPendingChanges();
                Console.WriteLine("Pended changes:");
                foreach (PendingChange pendingChange in pendingChanges)
                {
                    Console.WriteLine(" " + pendingChange.LocalItem + " (" + pendingChange.ChangeType + ")");
                }
                int changeset = workspace.CheckIn(pendingChanges, "Test from id " + uniqueId);
                Console.WriteLine("Checked in " + pendingChanges.Length + " as changeset " + changeset);
            }
        }
    }
