    DirectorySecurity ds = System.IO.Directory.GetAccessControl(@"C:\test");
    byte[] rawBytes = ds.GetSecurityDescriptorBinaryForm();
    RawSecurityDescriptor rsd = new RawSecurityDescriptor(rawBytes, 0);
    if ((rsd.ControlFlags & ControlFlags.DiscretionaryAclProtected) == 
                            ControlFlags.DiscretionaryAclProtected)
    {
        // "Include inheritable permissions from this object's parent" is unchecked
    }
    else
    {
        // "Include inheritable permissons from this object's parent" is checked
    }
