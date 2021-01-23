        [HttpPost]
        public ActionResult Save(PostViewModel viewModel)
        {
           // Map.
           var post = Mapper.Map<PostViewModel, Post>(viewModel);
           // Save.
           _postService.Save(post);
           // Redirect.
           return RedirectToAction("Index");
        }
