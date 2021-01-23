    XmlNodeList xprojects = xdoc.SelectNodes(projList);
    foreach (XmlNode xProject in xprojects)
    {
        string projectname = "";
        string projecttype = "";
        foreach(XmlNode xProjectAttr in xProject){
            switch(xProjectAttr.Name){
                case "ProjectName":
                    projectname = xProjectAttr.Value;
                    break;
                case "ProjectType":
                    projecttype = xProjectAttr.Value;
                    break;
            }
        }
        myProjects.buildProjectList(projectname,type);
    }
