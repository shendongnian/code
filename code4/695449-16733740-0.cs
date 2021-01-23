    var viewModelList = result.MyEnumerable.Select(s=> MyMapper(s))
     public static MyViewModel MyMapper(Item item)
        {
            var viewModel = new MyViewModel();
            //do some stuff
            return viewModel;
        }
