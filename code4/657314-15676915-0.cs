    public override UITableViewCell GetCell(UITableView tableView) {
        var cell = base.GetCell(tableView);
        cell.BackgroundColor = _colour;
        return cell;
    }
