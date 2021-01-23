    const string source = @"C:\test1\test";
    const string target = @"C:\test2\test";
    Directory.Move(source, target);
    
    // Get Directory Info
    var dInfo = new DirectoryInfo(target); // Or FileInfo
    var dSec = dInfo.GetAccessControl();
    // Set Security to inherit
    dSec.SetAccessRuleProtection(false, false);
    
    // Remove Rules/Accounts that are not inherited
    var rules = dSec.GetAccessRules(true, false, typeof (NTAccount));
    foreach (FileSystemAccessRule rule in rules)
        dSec.RemoveAccessRule(rule);
    
    // Commit changes to folder
    dInfo.SetAccessControl(dSec);
