    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using edu.stanford.nlp.process;
    using edu.stanford.nlp.util;
    
    namespace StanfordWrapper
    {
        public class SentenceTokenizer
        {
            public static readonly TokenizerFactory TokenizerFactory = PTBTokenizer.factory(new CoreLabelTokenFactory(),
                    "normalizeParentheses=false,normalizeOtherBrackets=false,invertible=true");
    
            public static List<string> Go( string input )
            {
                java.io.Reader reader = new java.io.StringReader(input);
                DocumentPreprocessor dp = new DocumentPreprocessor(reader);
                dp.setTokenizerFactory(TokenizerFactory);
    
                List<string> output = new List<string>();
                foreach (java.util.List sentence in dp)
                {
                    output.Add(StringUtils.joinWithOriginalWhiteSpace(sentence));
                }
    
                return output;
            }
        }
    }
