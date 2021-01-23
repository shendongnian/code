        Regex postCodeValidation = new Regex("[0234567]\d{4}");
        if (postCodeValidation.Match(post_code).Success)
        {
            // Post code is valid
        }
        else
        {
            // Post code is invlid
        }
