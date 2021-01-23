    using System;
    using System.Text;
    using Microsoft.Build.BuildEngine;
    namespace ConsoleApplication11
    {
        class Program
        {
            static void Main(string[] args)
            {
                var fullPathName = @"PathToProjectFile\Project.csproj";
                Project project = new Project();
                project.Load(fullPathName);
                var itemGroup = project.AddNewItemGroup();
                var buildItem = itemGroup.AddNewItem("Content", @"..\..\SomeFunFolder\MyLinkFile.ext");
                buildItem.SetMetadata("Link", "MyLinkFile.ext");
                project.Save(fullPathName, Encoding.UTF8);
            }
        }
    }
