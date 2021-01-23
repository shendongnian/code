                    thisConnection.Open();
                    List<ProjectWrapper> liProjectCOs = new List<ProjectWrapper>();
                    String ProjectQuery = "SELECT SF_CLIENT_PROJECT.ID, SF_CLIENT_PROJECT.NAMEX, SF_CHANGE_ORDER.ID, SF_CHANGE_ORDER.END_DATE, ";
                    ProjectQuery += "SF_CLIENT_PROJECT.CONTRACTED_START_DATE, SF_CHANGE_ORDER.STATUS, SF_CHANGE_ORDER.TYPE, SF_CLIENT_PROJECT.ESTIMATED_END_DATE, SF_CLIENT_PROJECT.CONTRACTED_END_DATE ";
                    ProjectQuery += "FROM SF_CLIENT_PROJECT, SF_CHANGE_ORDER ";
                    ProjectQuery += "WHERE SF_CHANGE_ORDER.TYPE = 'New' ";
                    ProjectQuery += "AND SF_CLIENT_PROJECT.ID = SF_CHANGE_ORDER.PROJECT";
                    ArrayList alProjects = GeneralQuery(ProjectQuery, thisConnection);
                    foreach( ArrayList proj in alProjects ) {
                        ProjectWrapper pw = new ProjectWrapper();
                        pw.projectId = Convert.ToString( proj[0] );
                        pw.projectId = Convert.ToString(proj[0]);
                        pw.projectName = Convert.ToString(proj[1]);
                        pw.changeOrderId = Convert.ToString(proj[2]);
                        pw.newEndDate = Convert.ToDateTime(proj[3]);
                        pw.startDate = Convert.ToDateTime(proj[4]);
                        pw.status = Convert.ToString(proj[5]);
                        pw.type = Convert.ToString(proj[6]);
                        if ( Convert.ToString(proj[7]) != "0" ) // 0 returned by generalquery if null
                            pw.oldEndDate = Convert.ToDateTime(proj[7]);
                        else
                            pw.oldEndDate = Convert.ToDateTime(proj[8]);
                        liProjectCOs.Add(pw);
