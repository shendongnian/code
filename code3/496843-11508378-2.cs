    #region Directives
        using System;
        using campusMap.Models;
        using MonoRailHelper;
        using campusMap.Services;
        using Castle.MonoRail.Framework;
        using campusMap.Filters;
        
        using SquishIt.Framework;
        using SquishIt.Framework.Css;
        using SquishIt.Framework.JavaScript;
        using System.Security.Cryptography;
    
    #endregion
    
    namespace campusMap.Services
    {
        public class ScriptsService
        {
            public static string CalculateMD5Hash(string input)
            {
                // step 1, calculate MD5 hash from input
                MD5 md5 = MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hash = md5.ComputeHash(inputBytes);
    
                // step 2, convert byte array to hex string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                return sb.ToString();
            }
    
            public static String Css(string files)
            {
                String name = CalculateMD5Hash(files);
                String path = @"/cache/script/css/";
                String FilePath = path + name + ".css";
    
                if (!HelperService.DirExists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                CSSBundle css = new CSSBundle();     
                foreach (string fl in files.Split(','))
                {
                    css.Add(fl);
                }
                return css.ForceRelease().Render(FilePath);
            }
            public static String Js(string files)
            {
    
                String name = CalculateMD5Hash(files);
                String path = @"/cache/script/js/";
                String FilePath = path + name + ".js" ;
    
                if (!HelperService.DirExists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                JavaScriptBundle js = new JavaScriptBundle();
                foreach (string fl in files.Split(','))
                {
                    js.Add(fl);
                }
                return js.ForceRelease().Render(FilePath);
            }
        }
    }
