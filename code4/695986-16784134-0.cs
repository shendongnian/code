    foreach(var postItem in viewModel.PostesItems){
       viewModel.ListG.ForEach((x)=>{
            if((x.PostId != postItem.Text) || (x.PostId != postItem.Value)){
               // Your logic goes here...
            }
       });
    }
