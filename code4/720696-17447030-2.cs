            var list = sp.Children.Cast<UserControl>();             // now we are able to use Linq
            var sublist = list.Where(item => item.Name == "name1"); // searching for all UserControl with the Name "name1"
            var uControl = sublist.FirstOrDefault();                // will result inyour UserControl or null
            //same as above just in one line
            var uControl2 = sp.Children.Cast<UserControl>().Where(item => item.Name == "name2").FirstOrDefault();
