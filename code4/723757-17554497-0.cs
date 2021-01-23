    using System;
    using System.Activities;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Microsoft.TeamFoundation.Build.Client;
     
    namespace MyBuildActivities.FileSystem
    {
        [BuildActivity(HostEnvironmentOption.Agent)]
        public sealed class ReadStringFromFile : CodeActivity
        {
            [RequiredArgument]
            public InArgument<IEnumerable<string>> Files { get; set; }
     
            [RequiredArgument]
            public InArgument<string> SearchString { get; set; }
     
            public OutArgument<string> Result { get; set; }
     
            protected override void Execute(CodeActivityContext context)
            {
                var files = context.GetValue(Files);
                var searchString = context.GetValue(SearchString);
     
                var list =
                    (files.Where(file => File.ReadAllText(file).Contains(searchString))
                        .Select(file => string.Format("{0} was found at {1}", searchString, file))).ToList();
     
                if(list.Count > 0)
                    Result.Set(context, string.Join(Environment.NewLine, list));
            }
        }
    }
