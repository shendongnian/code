    public class EditUserViewModel
    {
         public int UserId { get; set; }
    
         public string FirstName { get; set; }
    
         public string LastName { get; set; }
    
         public int OrganizationId { get; set; }
         public IEnumerable<Organization> Organizations { get; set; }
    }
    public ActionResult Edit(int id)
    {
         // Get the user by id
         User user = userRepository.GetById(id);
    
         // You can use a mapping tool here to map from domain model to view model.
         // I did it differently for the sake of simplicity
    
         EditAViewModel viewModel = new EditAViewModel
         {
              UserId = user.UserId,
              FirstName = user.FirstName,
              LastName = user.LastName,
              OrganizationId = user.OrganizationId,
              Organizations = organizationRepository.GetAll()
         };
         // Return the populated view model to the view    
         return View(viewModel);
    }
    [HttpPost]
    public ActionResult Edit(EditAViewModel viewModel)
    {
         if (!ModelState.IsValid)
         {
              viewModel.Organizations = organizationRepository.GetAll();
    
              return View(viewModel);
         }
    
         // If validation succeeds do what ever you have to do here, like edit in database
    }
