    \w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*
    Match a single character that is a “word character” (letters, digits, and underscores)     «\w+»
       Between one and unlimited times, as many times as possible, giving back as needed (greedy) «+»
    Match the regular expression below and capture its match into backreference number 1 «([-+.']\w+)*»
       Between zero and unlimited times, as many times as possible, giving back as needed (greedy) «*»
       Note: You repeated the capturing group itself.  The group will capture only the last  iteration.  Put a capturing group around the repeated group to capture all iterations. «*»
       Match a single character present in the list “-+.'” «[-+.']»
       Match a single character that is a “word character” (letters, digits, and underscores) «\w+»
          Between one and unlimited times, as many times as possible, giving back as needed (greedy) «+»
    Match the character “@” literally «@»
    Match a single character that is a “word character” (letters, digits, and underscores) «\w+»
       Between one and unlimited times, as many times as possible, giving back as needed (greedy) «+»
    Match the regular expression below and capture its match into backreference number 2 «([-.]\w+)*»
       Between zero and unlimited times, as many times as possible, giving back as needed (greedy) «*»
       Note: You repeated the capturing group itself.  The group will capture only the last iteration.  Put a capturing group around the repeated group to capture all iterations. «*»
       Match a single character present in the list “-.” «[-.]»
       Match a single character that is a “word character” (letters, digits, and underscores) «\w+»
          Between one and unlimited times, as many times as possible, giving back as needed (greedy) «+»
    Match the character “.” literally «\.»
    Match a single character that is a “word character” (letters, digits, and underscores) «\w+»
       Between one and unlimited times, as many times as possible, giving back as needed (greedy) «+»
    Match the regular expression below and capture its match into backreference number 3 «([-.]\w+)*»
       Between zero and unlimited times, as many times as possible, giving back as needed (greedy) «*»
       Note: You repeated the capturing group itself.  The group will capture only the last iteration.  Put a capturing group around the repeated group to capture all iterations. «*»
       Match a single character present in the list “-.” «[-.]»
       Match a single character that is a “word character” (letters, digits, and underscores) «\w+»
          Between one and unlimited times, as many times as possible, giving back as needed (greedy) «+»
