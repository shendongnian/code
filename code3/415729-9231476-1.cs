            string dllPathName = @"dllPath\dllFileName";
            string outputFilePathName = @"outputPath\outputFileName";
            System.Reflection.Assembly fileNetAssembly = System.Reflection.Assembly.LoadFrom(dllPathName);
            StringBuilder sb = new StringBuilder();
            foreach (Type cls in fileNetAssembly.GetTypes())
            {
                //only printing non interfaces that are abstract, public or sealed
                sb.Append(!cls.IsInterface ? (cls.IsAbstract ? string.Format("Class: {0} is Abstract.{1}", cls.Name, System.Environment.NewLine) :
                                                cls.IsPublic ? string.Format("Class: {0} is Public.{1}", cls.Name, System.Environment.NewLine) :
                                                cls.IsSealed ? string.Format("Class: {0} is Sealed.{1}", cls.Name, System.Environment.NewLine) :
                                                string.Empty) : 
                                            string.Empty);
                if (!cls.IsInterface && (cls.IsAbstract || cls.IsPublic || cls.IsSealed))
                {
                    //printing all methods within the class
                    foreach (System.Reflection.MemberInfo method in cls.GetMethods())
                    {
                        sb.Append("\t- ");
                        sb.Append(method.Name);
                        sb.Append(System.Environment.NewLine);
                    }
                }
            }
            //output the file
            File.WriteAllText(outputFilePathName, sb.ToString());
