    // The ViewModel is now a hirearchical model, where each item has a list of children.
    public class MenuViewModel
    {
        int MenuId {get; set;}
        string Name {get; set;}
        //other properties
        ** snip ** 
        List<MenuViewModel> Children {get; set;}
    }
