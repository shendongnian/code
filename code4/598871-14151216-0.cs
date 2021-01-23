           foreach(var c in Model.Chars) {
                string checkedStatus = "";
                if (Model.Project.ProjectCharacteristic.Any(x => x.CharacteristicID == c.CharacteristicID))
                {
                    checkedStatus = "checked";
                }
                <label class="label_check">
                    <input type="checkbox" name="Characteristic" value="@c.CharacteristicID" @checkedStatus> @c.CharacteristicName
                </label>
            }
