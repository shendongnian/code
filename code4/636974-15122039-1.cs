        using Bing;
        using System;
        using System.Data.Services.Client;
        using System.Linq;
        using System.Net;
        namespace StackOverflow.Samples.BingSearch
        {
            public class MyPage
            {
                private void Button_Click_1(object sender, RoutedEventArgs e)
                {
                    var finder = new Finder();
                    finder.FindImageUrlsForCompleted += finder_FindImageUrlsForCompleted;
                    finder.FindImageUrlsFor("candy");
                }
                void finder_FindImageUrlsForCompleted(object sender, List<string> result)
                {
                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                    {
                        foreach (var s in result)
                        {
                            MyTextBox.Text += s;
                            MyTextBox.Text += "\n";
                        }
                    });
                }
            }
        }
