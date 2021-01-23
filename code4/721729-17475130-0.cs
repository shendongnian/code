    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.Load("c:\\movies.xml");
                var movieModel = new MovieSummary();
                var MovieXML = xmlDoc.GetElementsByTagName("movie");
                movieModel.Movies = new List<Movie>();
                foreach (XmlElement element in MovieXML)
                {
                    movieModel.Movies.Add(new Movie(){movie = element.InnerText});                
                }
                //for (i = 0; i < MovieXML.Count; i++)
                //{
                //    movieModel.Movies[i].name = MovieXML[i]["name"].toString();
                //}
            }
        }
    }
