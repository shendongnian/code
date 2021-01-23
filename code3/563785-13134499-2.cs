    var xml = @"<doc>
            <members>
            <member test=""testing"" name=""T:QuexstBase.Tools.RegistryHelper.RegistryHelper"">
                <summary>
                RegistryHelper class to use registry operations.
                </summary>
            </member>
            <member test=""testing"" name=""F:QuexstBase.Tools.RegistryHelper.RegistryHelper.baseKey"">
                <summary>
                private member base key
                </summary>
            </member>
            <member  test=""tester""  name=""F:QuexstBase.Tools.RegistryHelper.RegistryHelper.subKey"">
                <summary>
                default sub key
                </summary>
            </member>
        </members>
    </doc>";
    var ms = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(xml));
    var doc = new XPathDocument(ms);
    var nav = doc.CreateNavigator();
    var nodes = nav.Select("//member[@test='testing']");
