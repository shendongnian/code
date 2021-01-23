    XmlNodeList xprojects = xdoc.SelectNodes(projList);
    foreach (XmlNode xNodeName in xprojects)
    {
        string projectname = xNodeName.SelectNodes("/ProjectName")[0].InnerText.ToString();
        string projecttype = xNodeName.SelectNodes("/ProjectType")[0].InnerText.ToString();
        myProjects.buildProjectList(projectname,type);
    }
