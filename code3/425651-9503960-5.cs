    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
     
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input = @"
                   <a asdf = href=  >BLANK</a>
                   <a href= a""'tz target=_self >ATZ</a>
                   <a href=/2012/02/26/world/meast/iraq-missing-soldier-id/index.html?hpt=hp_bn1 target=""_self"">Last missing U.S. soldier in Iraq ID'd</a>
                   <a id=""weatherLocBtn"" href=""javascript:MainLocalObj.Weather.checkInput('weather',document.localAllLookupForm.inputField.value);""><span>Go</span></a>
                   <a href=""javascript:CNN_handleOverlay('profile_signin_overlay')"">Log in</a>
                   <a no='href' here> NOT FOUND </a>
                   <a this href= is_ok > OK </a>
                ";
                string regex = @"
                   <a 
                     (?=\s) 
                     (?:[^>""']|""[^""]*""|'[^']*')*?
                     (?<=\s) href \s* =
                     (?: (?>              \s* (['""]) (?<URL>.*?)     \1       )
                       | (?> (?!\s*['""]) \s*         (?<URL>[^\s>]*) (?=\s|>) )   
                     )
                     (?> (?:"".*?""|'.*?'|[^>]?)+ )
                     (?<!/)
                   >
                   (?<TEXT>.*?)
                   </a \s*>
                ";
                string output = Regex.Replace(input, regex, "${TEXT} [${URL}]",
                                    RegexOptions.IgnoreCase |
                                    RegexOptions.Singleline |
                                    RegexOptions.IgnorePatternWhitespace);
    
                Console.WriteLine(input+"\n------------\n");
                Console.WriteLine(output);
            }
        }
    }
