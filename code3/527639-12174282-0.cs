    /// <summary>
    ///  Regular expression built for C# on: Wed, Aug 29, 2012, 09:56:25 AM
    ///  Using Expresso Version: 3.0.4334, http://www.ultrapico.com
    ///  
    ///  A description of the regular expression:
    ///  
    ///  [1]: A numbered capture group. [(?<counter>").*?(?<-counter>").*?(?(counter)(?!))]
    ///      (?<counter>").*?(?<-counter>").*?(?(counter)(?!))
    ///          [counter]: A named capture group. ["]
    ///              "
    ///          Any character, any number of repetitions, as few as possible
    ///          Balancing group. Remove the most recent [counter] capture from the stack. ["]
    ///              "
    ///          Any character, any number of repetitions, as few as possible
    ///          Conditional Expression with "Yes" clause only
    ///              Did the capture named [counter] match?
    ///              If yes, search for [(?!)]
    ///                  Match if suffix is absent. []
    ///                      NULL
    ///  \r\n
    ///      Carriage return
    ///      New line
    ///  
    ///
    /// </summary>
    Regex regex = new Regex(
    	  "((?<counter>\").*?(?<-counter>\").*?(?(counter)(?!)))\\r\\n",
    	RegexOptions.CultureInvariant
    	| RegexOptions.Compiled
    	| RegexOptions.Singleline
    	);
    string input = "INSERT INTO blah VALUES \" blah blah \r\n \" \r\n (here can be anything like several new lines and \t tabs) INSERT INTO blah VALUES \" blah blah \r\n \" \r\n";
    string output output=regex.Replace(input,"$1\n");
