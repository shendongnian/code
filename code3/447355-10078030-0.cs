    public enum TestFile { File1, File2 };
	
	public class TestFiles {
	  private static Dictionary<TestFile,string> _testFiles = new Dictionary<TestFile,string> {
		{ TestFile.File1, @"TestData\File1.xml" },
		{ TestFile.File2, @"TestData\File2.xml" },
      };
      public string RootPath() {
	    return @"C:\";
	  }
	  
	  public string Get( TestFile tf ) {
		return Path.Combine( RootPath(), _testFiles[tf] );
	  }
	  
	  // even better, you can override the array indexing operator
	  public string this[TestFile tf] {
	    get { 
			return Path.Combine( RootPath(), _testFiles[tf] );
		}
	  }
	}
