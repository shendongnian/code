    <table>
        @for (int i = 0; i < ViewBag.MyItems.Count; i++)
        {
            var cells = 4;
            var item = ViewBag.MyItems[i];
            if ((i % cells) == 0)
            {
                @:<tr>
            }
            <td>
                @item.MyTextOrWhatever
            </td>
            if (i == (ViewBag.MyItems.Count - 1))
            {
                while ((i % cells) != 0)
                {
                    @:<td></td>
                    i++;
                }
            }
            if ((i % cells) == (cells - 1)) // aka: last row cell
            {
                @:</tr>
            }
        }
    </table>
