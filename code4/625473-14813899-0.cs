    private string GenerateUL(IQueryable<Menu> menus)
    {
        var sb = new StringBuilder();
        sb.AppendLine("<ul>");
        foreach (var menu in menus)
        {
            if (menu.Menus.Any())
            {
                sb.AppendLine("<li>" + menu.Text);
                sb.Append(GenerateUL(menu.Menus.AsQueryable()));
                sb.AppendLine("</li>");
            } 
            else
                sb.AppendLine("<li>" + menu.Text + "</li>");
            }
        }
        sb.AppendLine("</ul>");
        return sb.ToString();
    }
