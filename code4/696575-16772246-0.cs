        public static DtsErrors RunSSISPackage(string packagePath, string MQProperty)
        {
                 * Append the auto generated GUID with the package name for running the SSIS package
                 */
                string uniqueId = Guid.NewGuid().ToString();
                string uniquePackage = Path.GetDirectoryName(packagePath) + @"\" + Path.GetFileNameWithoutExtension(packagePath) + "_" + uniqueId + ".dtsx";
                File.Copy(packagePath, uniquePackage);
                Package pkg;
                Microsoft.SqlServer.Dts.Runtime.Application app = new Microsoft.SqlServer.Dts.Runtime.Application();
                pkg = app.LoadPackage(uniquePackage, null);
                //MessageBox.Show(srcFileName);
                //MessageBox.Show(TPODBConnection);
                pkg.Connections["MQConnection"].<<YourPropertyName>> = MQProperty;
                DTSExecResult result = pkg.Execute();
                if (result == DTSExecResult.Failure)
                {
                    return pkg.Errors;
                }
                File.Delete(uniquePackage);
            return null;
        }
